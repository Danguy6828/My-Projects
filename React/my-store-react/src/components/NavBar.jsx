import { BsCart3, BsMoonFill, BsSunFill, BsFillCupHotFill, BsFillTreeFill, BsFillPaletteFill } from 'react-icons/bs';
import { FaBarsStaggered } from 'react-icons/fa6';
import { NavLink } from 'react-router-dom';
import NavLinks from './NavLinks';
import { useDispatch, useSelector } from 'react-redux';
import { luxuryTheme, nightTheme, forestTheme, coffeeTheme } from '../features/user/UserSlice';
import logo from '../assets/logo.png';

const NavBar = () => {
    const dispatch = useDispatch()
    const changeThemeLuxury = () => {
        dispatch(luxuryTheme())
    }
    const changeThemeNight = () => {
        dispatch(nightTheme())
    }
    const changeThemeForest = () => {
        dispatch(forestTheme())
    }
    const changeThemeCoffee = () => {
        dispatch(coffeeTheme())
    }
    const numItemsinCart = useSelector((state) => state.cartState.numItemsInCart)
    return (
        <nav className='bg-base-200'>
            <div className='navbar align-element'>
                <div className="navbar-start">
                    <NavLink  to='/' className='hidden lg:flex btn btn-secondary items-center'>
                        <img src={logo} className='w-10' />
                    </NavLink>
                    <div className="dropdown">
                        <label tabIndex={0} className='btn btn-ghost lg:hidden'>
                            <FaBarsStaggered className='h-6 w-6' />
                        </label>
                        <ul tabIndex={0} className='menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-200 rounded-box w-52'>
                            <NavLinks />
                        </ul>
                    </div>
                </div>
                <div className="navbar-center hidden lg:flex">
                    <ul className='menu menu-horizontal'><NavLinks /></ul>
                </div>
                <div className="navbar-end">
                    <div className='dropdown'>
                        <button tabIndex={0} type='button' className='btn btn-ghost btn-circle btn-md '>
                            <BsFillPaletteFill className='h-5 w-5' />
                        </button>
                        <ul tabIndex={0} className='menu dropdown-content mt-3 z-[1] p-2 shadow bg-base-200 rounded-box w-15'>
                            <li><button type="button" onClick={changeThemeLuxury}><BsSunFill className='h-6 w-6' /></button></li>
                            <li><button type="button" onClick={changeThemeNight}><BsMoonFill className='h-6 w-6' /></button></li>
                            <li><button type="button" onClick={changeThemeForest}><BsFillTreeFill className='h-6 w-6' /></button></li>
                            <li><button type="button" onClick={changeThemeCoffee}><BsFillCupHotFill className='h-6 w-6' /></button></li>
                        </ul>
                    </div>
                    <NavLink to='/cart' className='btn btn-ghost btn-circle btn-md'>
                        <div className="indicator">
                            <BsCart3 className='h-6 w-6' />
                            <span className='badge badge-sm badge-primary indicator-item'>
                                {numItemsinCart}
                            </span>
                        </div>
                    </NavLink>
                </div>
            </div>
        </nav>
    )
}

export default NavBar