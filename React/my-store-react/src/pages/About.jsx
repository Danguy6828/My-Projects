import React from 'react'

const About = () => {
  return (
    <>
      <div className="flex flex-wrap gap-2 sm:gap-x-6 items-center justify-center">
        <h1 className="text-4xl font-bold leading-none tracking-tight sm:text-6-xl">My name is</h1>
        <div className="stats bg-primary shadow">
          <div className="stat">
            <div className="stat-title text-primary-content text-4xl font-bold tracking-widest capitalize">
              david
            </div>
          </div>
        </div>
      </div>
      <p className='mt-6 text-lg leading-8 max-w-2xl mx-auto'>
        My name is David Nguyen. I am a student at WSU Tech, and I am currently going through the Cloud Computing program. Although I only had limited experience with coding before, it is interesting to learn about what goes on behind the scenes of the different programs and websites that I use on a regular basis. I hope this project is as interesting to you as it was for me.
      </p>
    </>
  )
}

export default About